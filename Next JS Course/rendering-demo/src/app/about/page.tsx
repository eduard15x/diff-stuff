import { cookies } from "next/headers";

export default async function AboutPage() {
  const cookiesStore = await cookies();
  const theme = cookiesStore.get("theme");
  console.log(theme);
  console.log("test");

  return <h1>About Page</h1>;
}
