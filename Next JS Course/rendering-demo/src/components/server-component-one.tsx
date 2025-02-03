import fs from "fs";
import { ServerComponentTwo } from "./server-component-two";
import { ClientComponentOne } from "./client-component-one";

export function ServerComponentOne() {
  fs.readFileSync("src/components/server-component-one.tsx", "utf-8");

  return (
    <div>
      <h1>Server Component One</h1>
      <ServerComponentTwo />
      <ClientComponentOne />
    </div>
  );
}
