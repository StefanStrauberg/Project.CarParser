// src/components/GradientText.tsx
import { Typography, type TypographyProps } from "@mui/material";

interface GradientTextProps extends TypographyProps {
  children: React.ReactNode;
}

const GradientText = ({ children, sx, ...props }: GradientTextProps) => {
  return (
    <Typography
      {...props}
      sx={{
        background: "linear-gradient(45deg, #0066ff, #ff4444, #ffffff)",
        backgroundClip: "text",
        WebkitBackgroundClip: "text",
        WebkitTextFillColor: "transparent",
        backgroundSize: "200% 200%",
        animation: "gradientShift 3s ease infinite",
        "@keyframes gradientShift": {
          "0%": {
            backgroundPosition: "0% 50%",
          },
          "50%": {
            backgroundPosition: "100% 50%",
          },
          "100%": {
            backgroundPosition: "0% 50%",
          },
        },
        ...sx,
      }}
    >
      {children}
    </Typography>
  );
};

export default GradientText;
