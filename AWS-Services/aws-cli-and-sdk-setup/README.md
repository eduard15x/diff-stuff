# AWS CLI & SDK Setup

This guide will help you set up the AWS CLI and SDK on your device. You'll learn how to create an access key, configure the CLI, and verify your setup.

---

## 1. Prerequisites

- **AWS account** with appropriate permissions  
- **Multi-Factor Authentication (MFA)** enabled (recommended)

---

## 2. Create an AWS Access Key

1. Log in to the [AWS Management Console](https://aws.amazon.com/console/).
2. In the top-right corner, click your account name and select **Security Credentials**.
3. Ensure MFA is set up.
4. Scroll to the **Access keys** section and click **Create Access Key**.
5. Check the acknowledgment box (note: using access keys is not best practice for long-term security).
6. Save the **Access Key ID** and **Secret Access Key** in a secure location.

---

## 3. Install the AWS CLI

- 📄 [Official Installation Guide](https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html)

**On macOS:**

```sh
brew install awscli
```

**Verify installation:**

```sh
which aws
aws --version
```

---

## 4. Configure the AWS CLI

- 📄 [AWS CLI Quickstart Guide](https://docs.aws.amazon.com/cli/latest/userguide/getting-started-quickstart.html#getting-started-quickstart-new)

Run the following command in your terminal:

```sh
aws configure
```

Provide the requested details:

```
AWS Access Key ID [None]: YOUR_ACCESS_KEY
AWS Secret Access Key [None]: YOUR_SECRET_ACCESS_KEY
Default region name [None]: eu-north-1
Default output format [None]: json
```

---

## 5. Verify Configuration Files

Navigate to your AWS configuration folder:

```sh
cd ~/.aws
```

You should see two files:

- `config`
- `credentials`

View their contents to confirm setup:

```sh
cat config
cat credentials
```

---

✅ **Your AWS CLI & SDK