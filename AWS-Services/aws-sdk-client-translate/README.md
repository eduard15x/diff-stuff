# AWS SDK Client Translate

This project provides a script to synchronize and translate JSON language files using [Amazon Translate](https://aws.amazon.com/translate/) via the AWS SDK for JavaScript.

## Prerequisites

- Node.js installed
- AWS account with access to Amazon Translate

## Setup AWS Credentials

### 1. Create an IAM User Group

1. Go to **IAM → User Groups** in the AWS Console.
2. Click **Create Group**.
3. Enter a name (e.g., `TranslateUsersGroup`).
4. Attach the following policies:
    - `AmazonTranslateFullAccess` (required)
    - `CloudWatchLogsFullAccess` (optional, for logging)

### 2. Create an IAM User

1. Go to **IAM → Users**.
2. Click **Create User**.
3. Enter a username (e.g., `translate-user`).
4. Uncheck **Provide user access to the AWS Management Console**.
5. Click **Next**.

### 3. Add the User to the Group

1. In **Add User to groups**, select your group (e.g., `TranslateUsersGroup`).
2. Click **Next** and then **Create User**.

### 4. Download Access Keys

1. Go to the user details page.
2. Under **Security credentials**, click **Create access key**.
3. Choose use case: **Application running outside AWS**.
4. Copy your `AWS_ACCESS_KEY_ID` and `AWS_SECRET_ACCESS_KEY`.

## Usage

1. Place your source and target translation files in the `translate-files` directory:
    - `translation-en.json` (source, English)
    - `translation-es.json` (target, Spanish, or other language)

2. Update your AWS credentials in `index.ts`:

    ```typescript
    const translate = new Translate({
      region: "your-region",
      credentials: {
        accessKeyId: "YOUR_AWS_ACCESS_KEY_ID",
        secretAccessKey: "YOUR_AWS_SECRET_ACCESS_KEY",
      },
    });
    ```

3. Run the script:

    ```sh
    npx ts-node index.ts
    ```

## How It Works

- The script compares the source and target translation files.
- Missing keys in the target file are translated using Amazon Translate.
- The target file is updated with new translations.

---

**Note:**  
Keep your AWS credentials secure. Never commit them to version control.
