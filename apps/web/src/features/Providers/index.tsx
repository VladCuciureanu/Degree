import { ReactNode } from "react";
import PlayerProvider from "./PlayerProvider";
import AuthProvider from "./AuthProvider";

type ProvidersProps = {
  children: ReactNode;
};

export default function Providers(props: ProvidersProps) {
  return (
    <AuthProvider>
      <PlayerProvider>{props.children}</PlayerProvider>
    </AuthProvider>
  );
}
