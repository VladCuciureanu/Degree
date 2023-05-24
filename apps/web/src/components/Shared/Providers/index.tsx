import { ReactNode } from "react";

type ProvidersProps = {
  children: ReactNode;
};

export default function Providers(props: ProvidersProps) {
  return <>{props.children}</>;
}
