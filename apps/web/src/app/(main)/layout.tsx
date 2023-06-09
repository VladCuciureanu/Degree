import Header from "@/components/Shared/Header";
import Player from "@/components/Shared/Player";
import { ReactNode } from "react";

export default function MainLayout({ children }: { children: ReactNode }) {
  return (
    <>
      <Header />
      {children}
      <Player />
    </>
  );
}
