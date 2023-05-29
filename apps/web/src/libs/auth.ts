import { LoginResponse } from "@/types/user";
import { fetchUrl } from "@/utils/fetch-url";

export function getAuthToken(
  username: string,
  password: string
): Promise<LoginResponse> {
  return fetchUrl(
    `${process.env.NEXT_PUBLIC_API_URL}/api/auth/login?` +
      new URLSearchParams({
        username,
        password,
      }),
    {
      method: "post",
    }
  ).then((res) => res.json());
}

export function createAccount(
  username: string,
  password: string
): Promise<Response> {
  return fetchUrl(
    `${process.env.NEXT_PUBLIC_API_URL}/api/auth/register?` +
      new URLSearchParams({
        username,
        password,
      }),
    {
      method: "post",
    }
  );
}
