# First Line in a Dockerfile starts with "FROM"

FROM node:22-alpine 

# Goes to the app directory (think of it like a cd terminal command)
WORKDIR /app

# We install first the packages on the local project
# Copy package.json and package-lock.json or yarn.lock files (if available)
COPY package*.json ./
COPY yarn.lock ./

# Install app dependencies
RUN yarn install

# Copy the rest of the application code
# But first we make sure we create a .dockerignore to avoid node_modules
COPY . .

# SET environment variables
ENV PORT=9000
# Expose the port the app runs on
EXPOSE 9000

# Run the APP
CMD ["yarn", "start"]