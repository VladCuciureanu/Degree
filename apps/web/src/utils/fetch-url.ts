export function fetchUrl(
  input: RequestInfo | URL,
  init?: RequestInit | undefined
): Promise<Response> {
  return fetch(input, init).then((res) => {
    if (!res.ok) {
      throw new Error("Failed to fetch data");
    }
    return res;
  });
}
