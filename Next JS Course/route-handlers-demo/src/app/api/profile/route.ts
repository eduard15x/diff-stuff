import { NextRequest } from "next/server";
import { headers, cookies } from "next/headers";

export async function GET(request: NextRequest) {
  const requestHeaders = new Headers(request.headers);
  const authorizationHeader = requestHeaders.get("Authorization");

  const headerListFromNextJs = headers();

  console.log((await headerListFromNextJs).get("Authorization"));
  console.log(authorizationHeader);
  console.log(typeof authorizationHeader);

  const themeCookie = request.cookies.get("theme");
  const cookiesNextJs = await cookies();
  const themeCookieFromNextJs = cookiesNextJs.get("theme");

  (await cookies()).set("test", "123");

  console.log(themeCookie);
  console.log(themeCookieFromNextJs);
  console.log(cookiesNextJs);

  return Response.json("<h1>profile api</h1>", {
    headers: { "Content-Type": "text/html", "Set-Cookie": "theme=dark" },
  });
}
