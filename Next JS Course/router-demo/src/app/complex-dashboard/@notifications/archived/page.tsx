import Card from "@/components/card";
import Link from "next/link";

export default function ArchivedNotifications() {
  return (
    <Card>
      <h1>ArchivedNotifications </h1>
      <Link href="/complex-dashboard">Notifications</Link>
    </Card>
  );
}
