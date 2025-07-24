import { Translate } from "@aws-sdk/client-translate";
import { readFileSync, writeFileSync } from "node:fs";

const compareTranslations = async (
  translate: Translate,
  source: any,
  target: any,
  targetLanguage: string
) => {
  const updatedTarget = target;

  for (const key in source) {
    if (typeof source[key] === "string") {
      if (!updatedTarget.hasOwnProperty(key)) {
        const translationResult = await translate.translateText({
          Text: source[key],
          SourceLanguageCode: "en",
          TargetLanguageCode: targetLanguage,
        });

        updatedTarget[key] = translationResult.TranslatedText;
      }
    } else {
      // If the value is an object, recursively compare translations
      updatedTarget[key] = await compareTranslations(
        translate,
        source[key],
        updatedTarget[key] || {},
        targetLanguage
      );
    }
  }

  return updatedTarget;
};

const compareTranslationsWithSyncDeletions = async (
  translate: Translate,
  source: any,
  target: any,
  targetLanguage: string
) => {
  const updatedTarget: any = {};

  for (const key in source) {
    const sourceValue = source[key];
    const targetValue = target?.[key];

    if (typeof sourceValue === "string") {
      if (typeof targetValue === "string") {
        updatedTarget[key] = targetValue;
      } else {
        const translationResult = await translate.translateText({
          Text: sourceValue,
          SourceLanguageCode: "en",
          TargetLanguageCode: targetLanguage,
        });
        updatedTarget[key] = translationResult.TranslatedText;
      }
    } else if (typeof sourceValue === "object" && sourceValue !== null) {
      updatedTarget[key] = await compareTranslations(
        translate,
        sourceValue,
        targetValue || {},
        targetLanguage
      );
    }
  }

  // Detect and log removed keys
  for (const key in target) {
    if (!source.hasOwnProperty(key)) {
      console.log(`❌ Removed key: ${key}`);
    }
  }

  return updatedTarget;
};

const startTranslation = async () => {
  const translate = new Translate({
    region: "eu-central-1",
    credentials: {
      accessKeyId: "AWS_ACCESS_KEY_ID",
      secretAccessKey: "AWS_SECRET_ACCESS_KEY",
    },
  });
  const translationPath = "./translate-files";

  const sourceEn = JSON.parse(
    readFileSync(`${translationPath}/translation-en.json`, "utf-8")
  );

  const targetEs = JSON.parse(
    readFileSync(`${translationPath}/translation-es.json`, "utf-8")
  );

  const updatedEs = await compareTranslations(
    translate,
    sourceEn,
    targetEs,
    "es"
  );

  writeFileSync(
    `${translationPath}/translation-es.json`,
    JSON.stringify(updatedEs, null, 4)
  );
};

console.log("Starting translation process...");
await startTranslation();
console.log("Ending translation process...");
