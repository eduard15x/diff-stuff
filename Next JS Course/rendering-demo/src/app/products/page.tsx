import Link from "next/link";

export default async function ProductsPage() {
  return (
    <div>
      <h1>Products Page</h1>

      <ul>
        <li>
          <Link href="/products/1">Product 1</Link>
        </li>
        <li>
          <Link href="/products/2">Product 2</Link>
        </li>
        <li>
          <Link href="/products/3">Product 3</Link>
        </li>
      </ul>
    </div>
  );
}
