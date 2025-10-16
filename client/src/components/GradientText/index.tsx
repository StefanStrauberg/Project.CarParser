// src/components/GradientText/index.tsx
import React from "react";
import { Typography, type TypographyProps } from "@mui/material";

export interface GradientTextProps extends Omit<TypographyProps, "variant"> {
  /** Текст/деталь внутри компонента */
  children: React.ReactNode;
  /** Вариант Typography по умолчанию – “h1” */
  variant?: TypographyProps["variant"];
}

/**
 * Компонент «градентный текст».
 *
 * @example
 * <GradientText variant="h3" sx={{ fontWeight: 700 }}>
 *   Hello, world!
 * </GradientText>
 */
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
      ...sx, // пользовательские стили переопределяют дефолтные
    }}
    {...props}
  >
    {children}
  </Typography>
);

export default GradientText;
