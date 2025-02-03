import Product from "@/components/product";
import Reviews from "@/components/reviews";
import { Suspense } from "react";

export default async function ProductReviews() {
  return (
    <div>
      <h1>Product Reviews</h1>
      <Suspense fallback={<h1>loading product...</h1>}>
        <Product />
      </Suspense>
      <Suspense fallback={<h1>loading reviews...</h1>}>
        <Reviews />
      </Suspense>
    </div>
  );
}
