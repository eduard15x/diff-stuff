# NEXTJS TUTORIAL

* create new project: npx create-next-app@latest
* start project: npm run dev / yarn dev

# REACT SERVER COMPONENTS (RSC)

* RSC is a new architecture introduced by the React team in version 18 which was quickly embraced by Next.js
* The architecture introduces a new way of creating React components, splitting them into two types:
  * Server components
  * Client components

## SERVER COMPONENTS

* In NEXT.js all components are SERVER components by default
* They have ability to run tasks like reading files or fetching data from a database
* They don't have the ability to use hooks or handle user interactions

## CLIENT COMPONENTS

* To create CLIENT components you have to add 'use client' at the top of the component file
* Can't perfom tasks like reading files, but they have the ability to use hooks and manage interactions

# ROUTING

* Next.js has a file-system based routing mechanism
* URL paths that users can access in the browser are defined by files and folders in your codebase
  * all routes must be placed inside the app folder
  * every file that corresponds to a route must be named page.js or page.tsx
  * every folder corresponds to a path segment in the browser URL

## FILE BASED ROUTING

* SCENARIO 1 - create page as index path ('/')
* SCENARIO 2 - create pages /about and /profile

* STRUCTURE
app folder -> localhost:3000/
about folder -> localhost:3000/about
    page.tsx
profile folder -> localhost:3000/profile
    page.tsx
layout.tsx
page.tsx

## NESTED ROUTES

* SCENARIO 3
    -localhost:3000/blog
    -localhost:3000/blog/first
    -localhost:3000/blog/second

blog folder -> localhost:3000/blog
    page.tsx
    first folder -> localhost:3000/blog/first
        page.tsx
    second folder -> localhost:3000/blog/second
        page.tsx

## DYNAMIC ROUTES

* SCENARIO 4
    -localhost:3000/products (list with product1, product2, product3)
    -localhost:3000/products/id -> products details
    -localhost:3000/products/1 -> product 1 details
    -localhost:3000/products/2 -> product 2 details

* SCENARIO 5
    -localhost:3000/products/1/reviews -> all reviews for product 1
    -localhost:3000/products/1/reviews/2 -> review nr 2 for product 1

# CATCH ALL SEGMENTS

* SCENARIO 6 (let's pretend we are creating a documentation site for a project) -> localhost:3000/docs/feature1/concept1
EX:
Feature1
    Concept1
    Concept2
    Concept3
    Concept4
Feature2
    Concept1
Feature3

* USE folder/[...slug]/page.tsx approach
! BETTER ORGANIZATION that is good for SEO

# NOT FOUND PAGE (404)

-generic one for entire application
-page based (single review using notFound() hook)

# FILE COLOCATION

* routing to page based on folder structure doesn't work or doesn't find the route if the page.tsx is not defined

# PRIVATE FOLDER

* feature provided by NEXT.js for better organization
* a private folder indicates that it is a private implementation detail and should not be considered by the routing system
* the folder and all its subfolders are excluded from routing
* prefix the folder name with underscore _
* for separating UI logic from routing logic
* for consistently organizing internal files accros a project
* for sorting/grouping files in code editors
* for avoiding naming conflicts with future Next.js file conventions

# ROUTE GROUPS

* allows us to logically group our rotates and project files withotu affecting the URL path structure
* example with authentication (register, login, forgot password)

* SCENARIO 7 - we want to group all routes in the auth folder so this is going to be /auth/register
    -to avoid "auth" from URL wrap the folder into parantheses ()
EXAMPLE:
(auth)
    register folder
        page.tsx
    login folder
        page.tsx

* because this now we can directly navigate to /register or /login

# LAYOUTS

* local state using with (useState hook) stay the same when navigating through routes in the same component (if is not re-mounted, like we do with templates)
* a page is UI that is unique to a route
* a layout is UI that is shared between multiple pages in the app

* define a layout by default exporting a react component from a layout.tsx file
* that component should accept a children prop that will be populated with a child page during rendering

# ROUTE GROUP LAYOUT

* check forgot-password

# IMPORTANT

# ROUTING METADATA

* ensuring proper SEO is crucial for increasing visibility and adttracting users
* next.js introduced the Metadata API which allows you to define metadata for each page
* metadata ensures accurate and relevant information is displayed when your pages are shared or indexed

## CONFIGURING METADATA

* export static metadata object
* export dynamic generateMetadata function

! RULES

* Both layout.tsx and page.tsx files can export metadata. If defined in a layout, it applies to all pages in that layout, but if defined in a page, it applies only to that page
* Metadata is read in order, from the root level down to the final page level
* when there is metadata in multile places for the same route, they get combined, but page metadata will replace layout metadata if they have the same properties

! check page.tsx in the about folder for static metadata
! and [productId] folder for dynamic metadata (generateMetadata function)

# LINK NAVIGATION

* file based routing
* users rely on UI elements like links to navigate (by clicking or programmatic navigation after completing an action)

* Link Component Navigation (import from next/link)

## ACTIVE LINK

* check auth folder -> layout.tsx
* usePathname() hook
* ! only with use client

## NAVIGATE PROGRAMMATICALLY

* works with 'use client'
* check order folder (using useRouter from next/navigation)

* example: router.push('/'), router.back(), router.forward()

* example (when you submit order, it redirect you to payment page or something)

# TEMPLATES

* the state is not preserverd anymore

* check (auth)/layout.tsx
* template files are similar to layouts in that they wrap each child layout or page
* but with templates, when a user navigates between routes that share a template, a new instance of the component is mounted, DOM elements are recreated, state is not preserved and effects are re-synchronized
* a template can be defined by exporting a default React Component from template.tsx file
* similar to layouts, templates also should accept a children prop which will render the nested segments in the route

# LOADING UI

* loading.tsx

* check blog folder
* the file allows us to create loading states that are displayed to users while a specifc route segment's content is loading
* the loading state appears immediately upon navigation, giving users the assurance that the application is responsive and actively loading content

## BENEFITS

* display loading state as soon as a user navigates, makes the application feel more responsive, reduces perceived loading times
* next.js allows the creating of shared layouts that remain interactive while new route segments are loading
* users can continue interacting with page (parts of the applciation) while  loading (ex: navigation menu or sidebar)

# ERROR HANDLING

* error.tsx

* ex: a failed fetch or network requests (we simulate into [reviewId]/page.tsx)
* wrap a route segment and its nested children in a React Error Boundary
* create error UI tailored to specific segments using the file-system hierarchy to adjust granularity
* add functionality to attempt to recover from an error without a full page reload

COMPONENT HIERARCHY (layout.tsx, template.tsx, error.tsx, loading.tsx, not-found.tsx, page.tsx)
<Layout>
    <Template>
        <ErrorBoundary fallback={<Error />}>
            <Suspense fallback={<Loading />}>
                <ErrorBoundary fallback={<NotFound />}>
                    <Page />
                </ErrorBoundary>
            </ErrorBoundary>
        </ErrorBoundary>
    </Template>
</Layout>

## RECOVERING FROM ERRORS

-check [reviewId]/error.tsx

## ERORS in NESTED ROUTES

* errors bubble up to the closest parent error boundary
* an error.tsx file will cater to errors for all its nested child segments
* by positioning error.tsx at a different level in the nested folders of a route, you can achieve a more granular level of error handling
( you can try to move error.tsx file a level up)

## ERRORS in LAYOUTS

* an error.tsx file will handle errors for all its nested segments

# PARALLEL ROUTES (ADVANCED PATTERN)

* we use SLOTS

* are an advanced routing mechanism that allows for the simultaneous rendering of multiple pages within the same layout
* SCENARIO 7 (think of a dashboard) and on the same page we have: user analytics, revenue metrics, notification

* slots help structure our content in a modular fashion
* to define a slot we use the '@folder' naming convention
* each slot is then passed as a prop to its corresponding "layout.tsx" file
* BENEFITS
  * split a single layout into various slots, making the code more manageable
  * independent route handling
  * sub-navigation (each slot can function as a mini-application)
  * each slot can have its own state/loading state/handling errors

# UNMATCHED ROUTES

* use default.tsx
* check complex-dashboard/@notifications/archieved folder
* if you try to reload page on complex-dashboard/archieved page will not be found (you will need default.tsx)

# CONDITIONAL ROUTES

* check @login slot in the complex-dashboard folder

# INTERCEPTION ROUTES (ADVANCED PATTERN) -> use (.)folder-name

* check f1 and f2 folders
* scenario (from a gallery list click an image, change url but just open a model -> if you refresh the url will navigate to the ImageDetails page)
* allow you to intercept or stop the default routing behaviour to present an alternate view
* this can be useful if you want to shwo while keeping the context of the current page
(.) to match segments on the same level
(..) to match segments one level above
(..)(..) to match segments two levels above ~ DOESNT WORK YET ~
(...) to match segments from the root app directory

# PARALLEL INTERCEPTING

* watch photo-feed example

# ROUTE HANDLERS

* we have learnt how to route pages
* we can also create custom request handlers for our routes using a feature calle d route handlers
* unlike page routes, which responds with HTML content, route handlers allow you to create RESTful endpoint, giving you full control over the response
* no need to create and configure a separate server
* route handlers are great for making external API requests (to 3rd parties for example)
* run server-side, ensuring that sensitive information like private keys remains secure and never get shipped to the browser

# CRUD REQUESTS

# QUERY PARAMETERS

# REDIRECTION

# H#ADERS

* represents the metadata associated with an API request and response

## Request Headers

* send by client, such as a web browser to the server
* they contain essential information about the request, which helps the server understand and process it correctly
* [User-Agent] which identifies the browser and operating system to the server
* [Accept] which indicated the content types like text, video, or image formats that the client can process
* [Authorization] header used by the client to authenticate itself to the server

## Response Headers

* sent back from the server to the client
* they provide information about the server and the data being setn in the response
* [Content-Type] indicated the media type of the response, what type of data is returned (text/html, application/json etc)

## Headers

* api/profile/route.ts

## Cookies

* api/profile/route.ts

* session management like logins and shopping carts
* personalization like user preferences and themes
* tracking like analyzing and recording user behavior

## CACHING

In Next 14, Route Handlers that used the GET HTTP method were cached by default unless they used a dynamic function or dynamic config option. In Next.js 15, GET functions are not cached by default. You can still opt into caching using a static route config option such as export dynamic = 'force-static'

## MIDDLEWARE

* create it at the root of src folder

* intercept and control requests/responses

# RENDERING

## generateStaticParams() -> products/[id]/page.tsx (single product pd)

export async function generateStaticParams() {
  return [{ id: "1" }, { id: "2" }, { id: "3" }];
}

* works alongside dynamic route segments
* generate static routes during build time
* performance boost

## dynamicParams() - export const dynamicParams = true / false

* control what happens when a dynamic segment is visited that was not generated with generateStaticParams() function

* true - statically render pages on demand for any dynamic segments not included in generateStaticParams()
* false - return a 404 error page for dynamic segments not included in our pre-rendered list

## STREAMING - use Suspense

* allows for progressive UI rendering from the server
* users can see parts of the page right away without waiting for everything to load
* powerful for improving initial page load times and handling UI elements that depend on slower data fetches, which would normally hold up the entire route

## SERVER & CLIENT Composition Patterns

* Server Components
  * fetching data
  * accessing backend resources directly
  * keeping sensitive information (access tokens and API keys) secure on the server
  * handling large dependencies server-side -> less js for users to download

* Client Components
  * adding interactivity
  * handling event listeners
  * managing states and lifecycles effects
  * impementing custom hooks

### SERVER-ONLY CODE - server-only package

* avoid importing server only code into client components

### THIRD-PARTY Packages

* example: react-slik carousel
* create a component for the carousel and import it in a server component without using 'use client' (this component will be also server but client component)

### CONTEXT PROVIDERS

* to share global state
* react context not supported in server components
* SOLUTION: create context and render its provider inside a dedicated CLIENT COMPONENT

# CLIENT-ONLY-CODE

* to prevent unintended server side usage of client side code, we can use a package called client-only
* client-only code works with browser-specific featured - think DOM manipulation, window object interactions or localStorage operations

# INTERLEAVING SERVER & CLIENT COMPONENTS

# FETCHING DATA & MUTATIONS

## FETCHING DATA IN CLIENT COMPONENTS

* classic way

## FETCHING DATA IN SERVER COMPONENTS

* almost classic way, but for loading and error handling you need new files

## SEQUENTIAL DATA FETCHING - DATA FETCHING PATTERNS

1. SEQUENTIAL
    * requests in a component tree are dependend on each other -> this can lead to longer loading times (you need to use Suspense)

2. PARALLEL
    * requests in a route are eagerly initiated and will load data at the same time -> this reduces the total time it takes to load data

## FETCHING FROM DATABASE

* SQLite + Prisma

## useFormStatus
