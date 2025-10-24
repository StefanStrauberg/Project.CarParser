import type { Theme } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";

// src/layout/appBackgroundStyles.ts
export const appBackgroundStyles = {
  root: (image: string): SxProps<Theme> => ({
    minHeight: "100vh",
    position: "relative",
    overflow: "hidden",
    backgroundImage: `url(${image})`,
    backgroundSize: "cover",
    backgroundPosition: "center",
    backgroundRepeat: "no-repeat",
    backgroundAttachment: "fixed",
    "&::before": {
      content: '""',
      position: "absolute",
      top: 0,
      left: 0,
      right: 0,
      bottom: 0,
      background: `
        linear-gradient(
          135deg,
          rgba(0, 100, 255, 0.25) 0%,
          rgba(255, 50, 50, 0.15) 50%,
          rgba(150, 0, 0, 0.2) 100%
        ),
        radial-gradient(circle at 20% 80%, rgba(0, 102, 255, 0.2) 0%, transparent 50%),
        radial-gradient(circle at 80% 20%, rgba(255, 68, 68, 0.15) 0%, transparent 50%)
      `,
      backdropFilter: "contrast(1.1) saturate(1.1) blur(0.5px)",
      pointerEvents: "none",
    },
    "&::after": {
      content: '""',
      position: "absolute",
      top: 0,
      left: 0,
      right: 0,
      bottom: 0,
      background: `
        linear-gradient(90deg, 
          transparent 0%, 
          rgba(0, 100, 255, 0.03) 50%, 
          transparent 100%
        ),
        linear-gradient(0deg, 
          transparent 0%, 
          rgba(255, 50, 50, 0.02) 50%, 
          transparent 100%
        )
      `,
      backgroundSize: "60px 60px",
      opacity: 0.3,
      pointerEvents: "none",
    },
  }),

  glassOverlay: {
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    background: `
    linear-gradient(135deg, rgba(0, 0, 0, 0.3), rgba(20, 30, 50, 0.4)),
    radial-gradient(circle at 50% 50%, rgba(0, 170, 255, 0.05), transparent 70%)
  `,
    backdropFilter: "blur(3px) saturate(120%) contrast(1.2)",
    pointerEvents: "none",
    zIndex: 1,
  } as SxProps<Theme>,

  scanLine: {
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    height: "1px",
    background:
      "linear-gradient(90deg, transparent, #00aaff, #ff4444, transparent)",
    animation: "scanLine 12s linear infinite",
    boxShadow: "0 0 8px #00aaff, 0 0 4px #ff4444",
    opacity: 0.4,
    zIndex: 1,
    "@keyframes scanLine": {
      "0%": { transform: "translateY(0)" },
      "100%": { transform: "translateY(100vh)" },
    },
  } as SxProps<Theme>,

  pulseRed: {
    position: "absolute",
    top: "30%",
    left: 0,
    right: 0,
    height: "1px",
    background: "linear-gradient(90deg, transparent, #ff4444, transparent)",
    animation: "pulseRed 8s ease-in-out infinite",
    opacity: 0.2,
    zIndex: 1,
    "@keyframes pulseRed": {
      "0%, 100%": { opacity: 0.1 },
      "50%": { opacity: 0.3 },
    },
  } as SxProps<Theme>,

  pulseBlue: {
    position: "absolute",
    top: "60%",
    left: 0,
    right: 0,
    height: "1px",
    background: "linear-gradient(90deg, transparent, #00aaff, transparent)",
    animation: "pulseBlue 6s ease-in-out infinite 2s",
    opacity: 0.2,
    zIndex: 1,
    "@keyframes pulseBlue": {
      "0%, 100%": { opacity: 0.1 },
      "50%": { opacity: 0.3 },
    },
  } as SxProps<Theme>,

  contentWrapper: {
    position: "relative",
    zIndex: 2,
    minHeight: "100vh",
  } as SxProps<Theme>,
};
