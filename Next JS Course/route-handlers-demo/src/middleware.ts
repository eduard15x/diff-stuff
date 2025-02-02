import { NextRequest, NextResponse } from "next/server";

export function middleware(request: NextRequest) {
  console.log("middleware");
  console.log("middleware");
  console.log("middleware");
  console.log("middleware");

  if (request.nextUrl.pathname === "/api/profile") {
    // return NextResponse.redirect(new URL("/hello", request.nextUrl));

    // ! for better SEO you can rewrite the url to serve another page
    return NextResponse.rewrite(new URL("/hello", request.nextUrl));
  }

  // return NextResponse.redirect(new URL("/", request.url));
}

// export const config = {
//   matcher: "/api/profile",
// };
