import Header from "@/features/Header";
import { ReactNode } from "react";

export default function SecondaryLayout({ children }: { children: ReactNode }) {
  return (
    <>
      <Header />
      {children}
    </>
  );
}
