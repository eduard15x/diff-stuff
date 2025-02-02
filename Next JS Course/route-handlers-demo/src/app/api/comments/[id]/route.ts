import { redirect } from "next/navigation";
import { comments } from "../../dummy-data/data";

export async function GET(
  request: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  const { id } = await params;
  const comment = comments.find((comm) => comm.id === parseInt(id));
  if (comment) {
    return Response.json(comment);
  } else {
    redirect("/api/comments");
  }
}

export async function PATCH(
  request: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  const body = await request.json();
  const { text } = body;

  const { id } = await params;
  const index = comments.findIndex((comm) => comm.id === parseInt(id));
  comments[index].text = text;

  return Response.json(comments[index]);
}

export async function DELETE(
  request: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  const { id } = await params;
  const index = comments.findIndex((comm) => comm.id === parseInt(id));
  comments.splice(index, 1);

  return new Response(`Comment with id ${index} was deleted.`);
}
