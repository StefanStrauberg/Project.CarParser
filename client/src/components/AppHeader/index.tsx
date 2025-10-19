// src/components/AppBar/index.tsx
import { AppBar, Toolbar, Box, Button, alpha } from "@mui/material";
import { CarRental } from "@mui/icons-material";
import { useLocation, useNavigate } from "react-router-dom";
import GradientText from "../GradientText";

const AppHeader = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const tabs = [
    { key: "/", label: "Car Listings" },
    { key: "/engine-types", label: "Engine Type" },
    { key: "/place-cities", label: "Place Cities" },
    { key: "/place-regions", label: "Place Regions" },
    { key: "/transmission-types", label: "Transmission Types" },
  ];

  const isActiveTab = (path: string) => {
    if (path === "/") {
      return location.pathname === "/";
    }
    return location.pathname.startsWith(path);
  };

  return (
    <AppBar
      position="sticky"
      elevation={0}
      sx={{
        background: alpha("#1a1a2e", 0.9),
        backdropFilter: "blur(20px)",
        borderBottom: `1px solid ${alpha("#6366f1", 0.1)}`,
      }}
    >
      <Toolbar>
        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          <Box
            sx={{
              background: "linear-gradient(45deg, #6366f1, #ec4899)",
              borderRadius: "12px",
              p: 1,
            }}
          >
            <CarRental sx={{ color: "#fff", fontSize: 28 }} />
          </Box>
          <GradientText
            variant="h6"
            sx={{
              fontWeight: 700,
              cursor: "pointer",
            }}
            onClick={() => navigate("/")}
          >
            CarParser
          </GradientText>
        </Box>

        <Box sx={{ flexGrow: 1 }} />

        {/* Кнопки навигации для десктопа */}
        <Box
          sx={{
            display: { xs: "none", md: "flex" },
            alignItems: "center",
            gap: 1,
          }}
        >
          {tabs.map((tab) => (
            <Button
              key={tab.key}
              color="inherit"
              onClick={() => navigate(tab.key)}
              sx={{
                transition: "all 0.3s ease",
                background: isActiveTab(tab.key)
                  ? alpha("#6366f1", 0.2)
                  : "transparent",
                border: isActiveTab(tab.key)
                  ? `1px solid ${alpha("#6366f1", 0.3)}`
                  : "1px solid transparent",
                borderRadius: "8px",
                px: 2,
                py: 0.5,
                "&:hover": {
                  background: alpha("#6366f1", 0.1),
                  transform: "translateY(-1px)",
                },
              }}
            >
              {tab.label}
            </Button>
          ))}
        </Box>
      </Toolbar>

      {/* Мобильная версия кнопок */}
      <Toolbar
        sx={{
          display: { xs: "flex", md: "none" },
          gap: 1,
          overflowX: "auto",
          py: 1,
        }}
      >
        {tabs.map((tab) => (
          <Button
            key={tab.key}
            color="inherit"
            size="small"
            onClick={() => navigate(tab.key)}
            sx={{
              flexShrink: 0,
              transition: "all 0.3s ease",
              background: isActiveTab(tab.key)
                ? alpha("#6366f1", 0.2)
                : "transparent",
              border: isActiveTab(tab.key)
                ? `1px solid ${alpha("#6366f1", 0.3)}`
                : "1px solid transparent",
              borderRadius: "6px",
              px: 1.5,
              "&:hover": {
                background: alpha("#6366f1", 0.1),
              },
            }}
          >
            {tab.label}
          </Button>
        ))}
      </Toolbar>
    </AppBar>
  );
};

export default AppHeader;
