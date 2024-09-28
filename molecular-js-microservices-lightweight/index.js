import UserService from "./services/user.service.js";
import EmailService from "./services/email.service.js";

async function startApp() {
  // start our services
  await UserService.start();
  await EmailService.start();

  try {
    // simulate user creation
    const newUser = await UserService.call("user.createUser", {
      username: "Johny",
      email: "johny@gmail.com",
    });
    console.log("New User Created- index.js", newUser);

    const userList = await UserService.call("user.getUsers", {});
    console.log("User List", userList);

    // Simulate sending email
    const emailResult = await EmailService.call("email.sendEmail", {
      recipient: newUser.username,
      subject: "Welcome to our platform!",
      content: "Thank you for signing up.",
    });

    console.log(emailResult);
  } catch (error) {
    console.error("Error", error);
  } finally {
    await UserService.stop();
    await EmailService.stop();
  }
}

startApp();
