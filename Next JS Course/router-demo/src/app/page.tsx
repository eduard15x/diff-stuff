import Link from "next/link";

export default function Home() {
  return (
    <div>
      <h1>Welcome Home!</h1>

      <hr />

      <Link href="/blog">Blog</Link>
      <Link href="/products">Products</Link>
    </div>
  );
}
