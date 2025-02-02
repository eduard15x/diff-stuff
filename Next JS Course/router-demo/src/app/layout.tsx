import { Metadata } from "next";

export const metadata: Metadata = {
  title: {
    absolute: "", // this will ignore title-template if you set it in another page (ex about have a title, will avoid having the template from here)
    default: "Next.js tutorial - codevolution", // when you want to provide a fallback for children pages that doesnt set a title
    template: "%s | CodeEvolution", // create dynamic title to create prefix
  },
  description: "Next.js metadata in the layout",
};

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <header>
          <p>Header in layout</p>
        </header>
        {children}

        <footer>
          <p>Footer in layout</p>
        </footer>
      </body>
    </html>
  );
}
