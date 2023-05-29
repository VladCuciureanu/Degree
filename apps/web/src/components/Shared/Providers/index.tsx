import { ReactNode } from "react";
import PlayerProvider from "./PlayerProvider";

type ProvidersProps = {
  children: ReactNode;
};

export default function Providers(props: ProvidersProps) {
  return <PlayerProvider>{props.children}</PlayerProvider>;
}
