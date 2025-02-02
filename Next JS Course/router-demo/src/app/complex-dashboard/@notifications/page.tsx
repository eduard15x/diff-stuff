import Card from "@/components/card";
import Link from "next/link";

export default function Notifications() {
  return (
    <Card>
      <h1>Notifications </h1>
      <Link href="/complex-dashboard/archived">Archieved</Link>
    </Card>
  );
}
