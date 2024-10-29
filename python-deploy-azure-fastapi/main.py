from fastapi import FastAPI

# Create an instance of FastAPI
app = FastAPI()

# Define a simple endpoint
@app.get("/")
async def read_root():
    return {"message": "Hello, World!"}

@app.get("/greet/{name}")
async def greet_user(name: str):
    return {"message": f"Hello, {name}!"}