"use client";

import { useRouter } from "next/navigation";

export default function OrderProduct() {
  const router = useRouter();

  const handleClick = () => {
    console.log("place order");
    router.push("/");
  };

  return (
    <div>
      <h1>Welcome OrderProduct!</h1>
      <button onClick={handleClick}>Place Order</button>
    </div>
  );
}
