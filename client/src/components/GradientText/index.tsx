// src/components/GradientText/index.tsx
import React from "react";
import { Typography, type TypographyProps } from "@mui/material";

export interface GradientTextProps extends Omit<TypographyProps, "variant"> {
  children: React.ReactNode;
  variant?: TypographyProps["variant"];
}

const GradientText: React.FC<GradientTextProps> = ({
  children,
  variant = "h1",
  sx,
  ...props
}) => (
  <Typography
    variant={variant}
    sx={{
      background: "linear-gradient(45deg, #818cf8 30%, #f472b6 90%)",
      backgroundClip: "text",
      WebkitBackgroundClip: "text",
      WebkitTextFillColor: "transparent",
      ...sx,
    }}
    {...props}
  >
    {children}
  </Typography>
);

export default GradientText;
