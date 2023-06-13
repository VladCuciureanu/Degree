import Header from "@/features/Header";
import Player from "@/features/Player";
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
