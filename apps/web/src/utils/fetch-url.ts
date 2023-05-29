export function fetchUrl(
  input: RequestInfo | URL,
  init?: RequestInit | undefined
): Promise<Response> {
  const headers: HeadersInit = {};

  if (typeof window !== "undefined" && localStorage.getItem("token")) {
    headers["Authorization"] = `Bearer ${localStorage.getItem("token")}`;
  }

  return fetch(input, { ...init, headers }).then((res) => {
    if (res.status === 401) {
      // TODO: Redirect to auth;
    }

    if (!res.ok) {
      throw new Error("Failed to fetch data");
    }

    return res;
  });
}
