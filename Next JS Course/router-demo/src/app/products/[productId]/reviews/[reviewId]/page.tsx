import { notFound } from "next/navigation";

const getRandomInt = (count: number) => Math.floor(Math.random() * count);

export default async function ReviewDetails({
  params,
}: {
  params: Promise<{ productId: string; reviewId: string }>;
}) {
  console.log("params");
  console.log(params);

  const { productId, reviewId } = await params;

  const random = getRandomInt(2);
  console.log(random);

  if (random === 1) {
    throw new Error("Error loading review");
  }

  if (parseInt(reviewId) > 1000) {
    notFound();
  }

  return (
    <h1>
      Review {reviewId} Details for Product with ID {productId}{" "}
    </h1>
  );
}
