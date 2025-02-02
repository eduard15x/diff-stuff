export default function ProductDetailsLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      {" "}
      <div>
        <p>Header layout in ProductID </p>
      </div>
      {children}
      <div>
        <p>Footer layout in ProductID </p>
      </div>
    </>
  );
}
