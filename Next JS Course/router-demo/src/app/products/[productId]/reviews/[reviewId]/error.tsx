"use client";

export default function ErrorBoundary({
  error,
  reset,
}: {
  error: Error;
  reset: () => void;
}) {
  return (
    <div>
      <h2>Error in review id</h2>
      <p>Error message: {error.message}</p>
      <button onClick={reset}>Try Again</button>
    </div>
  );
}
