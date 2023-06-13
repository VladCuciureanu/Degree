import "@/styles/globals.scss";
import styles from "./layout.module.scss";
import Header from "@/features/Header";
import Player from "@/features/Player";
import Providers from "@/features/Providers";
import { cn } from "@/utils/class-names";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

export const metadata = {
  title: "AudioStreaming",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={cn(inter.className, styles.Container)}>
        <Providers>{children}</Providers>
      </body>
    </html>
  );
}
