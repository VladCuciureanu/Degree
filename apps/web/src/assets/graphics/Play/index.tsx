import { ComponentProps } from "react";

export default function PlayIcon(props: ComponentProps<"svg">) {
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
      <polygon points="0,0 0,16 16,8 " />
    </svg>
  );
}
