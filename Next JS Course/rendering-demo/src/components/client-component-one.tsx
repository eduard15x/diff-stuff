"use client";

import { useState } from "react";
import { ClientComponentTwo } from "./client-component-two";

export function ClientComponentOne() {
  const [name, setName] = useState<string>("Batman");
  return (
    <div>
      <h1>Client Component One</h1>;
      <ClientComponentTwo />
    </div>
  );
}
