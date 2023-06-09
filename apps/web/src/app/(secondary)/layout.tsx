import Header from "@/components/Shared/Header";
import { ReactNode } from "react";

export default function SecondaryLayout({ children }: { children: ReactNode }) {
  return (
    <>
      <Header />
      {children}
    </>
  );
}
