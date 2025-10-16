// src/components/GradientChip/index.tsx
import React from "react";
import Chip, { type ChipProps } from "@mui/material/Chip";

export interface GradientChipProps extends Omit<ChipProps, "label"> {
  /** Текст, который будет отображён внутри чипа */
  label: React.ReactNode;
  /** Дополнительные стили (если нужно переопределить дефолтные) */
  sx?: ChipProps["sx"];
}

/**
 * Чип с градиентным фоном.
 *
 * @example
 * <GradientChip label="New" variant="outlined" />
 */
const GradientChip: React.FC<GradientChipProps> = ({ label, sx, ...props }) => (
  <Chip
    label={label}
    sx={{
      background: "linear-gradient(45deg, #6366f1, #818cf8)",
      color: "#fff",
      fontWeight: 600,
      ...sx, // пользовательские стили переопределяют дефолтные
    }}
    {...props}
  />
);

// Если хотите сэкономить перерисовки – раскомментируйте строку ниже
// export default React.memo(GradientChip);

export default GradientChip;
