"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import { useEffect, useState } from "react";

import "./style.css";

export default function AuthLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const navLinks = [
    { name: "Register", href: "/register" },
    { name: "Login", href: "/login" },
    { name: "Forgot Password", href: "/forgot-password" },
  ];

  const rawPathname = usePathname();
  const [pathname, setPathname] = useState("");

  useEffect(() => {
    setPathname(rawPathname); // Ensure it runs only on the client
  }, [rawPathname]);

  const [input, setInput] = useState("");

  return (
    <div>
      <h1>AUTH LAYOUT GENERAL</h1>

      <div>check pathname variable</div>
      <div>pathname: {pathname || "Loading..."}</div>

      <br />
      <br />
      <div>check use state input variable</div>
      <input
        className="border-2 border-red-600"
        value={input}
        onChange={(e) => setInput(e.target.value)}
      />
      <div>input value: {input}</div>

      <div>
        {navLinks.map((link) => {
          const isActive = pathname?.startsWith(link.href);

          return (
            <h2 key={link.name}>
              <Link
                href={link.href}
                className={isActive ? "font-bold mr-4" : "text-blue-500 mr-4"}
              >
                {link.name}
              </Link>
            </h2>
          );
        })}
      </div>

      <div>{children}</div>
    </div>
  );
}
