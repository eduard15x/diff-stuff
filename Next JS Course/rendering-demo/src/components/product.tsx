export default async function Product() {
  await new Promise((resolve) => setTimeout(resolve, 1500));
  return <h1>Products</h1>;
}
