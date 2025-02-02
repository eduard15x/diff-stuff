import Link from "next/link";

export default function F4() {
  return (
    <div>
      <h1>F4 page!</h1>
      <div>
        <Link href="/f1/f3">F3</Link>
        <Link href="/about">About</Link>
      </div>
    </div>
  );
}
