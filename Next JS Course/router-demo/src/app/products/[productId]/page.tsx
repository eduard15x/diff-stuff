import { Metadata } from "next";

type Props = {
  params: Promise<{
    productId: string;
  }>;
};

export const generateMetadata = async ({
  params,
}: Props): Promise<Metadata> => {
  const { productId } = await params;
  const title = await new Promise((resolve) => {
    setTimeout(() => {
      resolve(`iPhone ${productId}`);
    }, 100);
  });

  return {
    title: `Product ${title}`,
  };
};

export default async function ProductDetails({ params }: Props) {
  const { productId } = await params;
  console.log("params");
  console.log(params);
  return <h1>Product Details - {productId} </h1>;
}
