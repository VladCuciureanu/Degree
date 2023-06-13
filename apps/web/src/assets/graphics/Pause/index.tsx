import { ComponentProps } from "react";

export default function PauseIcon(props: ComponentProps<"svg">) {
  return (
    <svg
      version="1.1"
      id="Layer_1"
      xmlns="http://www.w3.org/2000/svg"
      x="0px"
      y="0px"
      viewBox="0 0 16 16"
      {...props}
    >
      <rect width="5" height="16" />
      <rect x="11" width="5" height="16" />
    </svg>
  );
}
