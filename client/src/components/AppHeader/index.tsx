// src/components/AppHeader/index.tsx
import { AppBar, Toolbar, Box, Button, alpha, IconButton } from "@mui/material";
import { CarRental, AccountCircle, MilitaryTech } from "@mui/icons-material";
import { useLocation, useNavigate } from "react-router-dom";
import GradientText from "../GradientText";

const AppHeader = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const isAuthenticated = localStorage.getItem("isAuthenticated") === "true";

  const tabs = [
    { key: "/", label: "VEHICLE DATABASE" },
    { key: "/engine-types", label: "ENGINE SYSTEMS" },
    { key: "/place-cities", label: "LOCATION DATA" },
    { key: "/place-regions", label: "REGION MAP" },
    { key: "/transmission-types", label: "TRANSMISSION" },
  ];

  const isActiveTab = (path: string) => {
    if (path === "/") {
      return location.pathname === "/";
    }
    return location.pathname.startsWith(path);
  };

  const handleAuthClick = () => {
    if (isAuthenticated) {
      localStorage.removeItem("isAuthenticated");
      window.location.reload();
    } else {
      navigate("/login");
    }
  };

  return (
    <AppBar
      position="sticky"
      elevation={0}
      sx={{
        background: alpha("#0a0e17", 0.95),
        backdropFilter: "blur(20px)",
        borderBottom: `1px solid ${alpha("#0066ff", 0.3)}`,
        boxShadow: "0 2px 30px rgba(0, 102, 255, 0.2)",
      }}
    >
      <Toolbar>
        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          <Box
            sx={{
              background: "linear-gradient(45deg, #0066ff, #ff4444)",
              borderRadius: "4px",
              p: 1,
              boxShadow: "0 0 15px rgba(0, 102, 255, 0.4)",
              position: "relative",
              "&::after": {
                content: '""',
                position: "absolute",
                top: 1,
                left: 1,
                right: 1,
                bottom: 1,
                border: "1px solid rgba(255, 255, 255, 0.3)",
                borderRadius: "2px",
              },
            }}
          >
            <CarRental sx={{ color: "#fff", fontSize: 28 }} />
          </Box>
          <GradientText
            variant="h6"
            sx={{
              fontWeight: 700,
              cursor: "pointer",
              letterSpacing: "1px",
              textShadow: "0 0 20px rgba(0, 102, 255, 0.5)",
            }}
            onClick={() => navigate("/")}
          >
            CARPARSER
          </GradientText>
        </Box>
        <Box sx={{ flexGrow: 1 }} />

        {/* Навигация для десктопа */}
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
                  ? alpha("#0066ff", 0.2)
                  : "transparent",
                border: isActiveTab(tab.key)
                  ? `1px solid ${alpha("#0066ff", 0.4)}`
                  : "1px solid transparent",
                borderRadius: "4px",
                px: 2,
                py: 0.8,
                fontSize: "0.75rem",
                fontWeight: 600,
                letterSpacing: "0.5px",
                minWidth: "auto",
                "&:hover": {
                  background: alpha("#0066ff", 0.15),
                  borderColor: alpha("#00aaff", 0.5),
                  transform: "translateY(-1px)",
                  boxShadow: "0 4px 12px rgba(0, 102, 255, 0.3)",
                },
              }}
            >
              {tab.label}
            </Button>
          ))}
        </Box>

        {/* Кнопка авторизации */}
        <IconButton
          onClick={handleAuthClick}
          sx={{
            ml: 2,
            background: isAuthenticated
              ? "linear-gradient(45deg, #00ff88, #00cc66)"
              : "linear-gradient(45deg, #0066ff, #ff4444)",
            color: "white",
            "&:hover": {
              transform: "translateY(-2px)",
              boxShadow: "0 8px 20px rgba(0, 102, 255, 0.4)",
            },
            transition: "all 0.3s ease",
            border: `1px solid ${alpha("#fff", 0.2)}`,
          }}
        >
          {isAuthenticated ? <MilitaryTech /> : <AccountCircle />}
        </IconButton>
      </Toolbar>

      {/* Мобильная навигация */}
      <Toolbar
        sx={{
          display: { xs: "flex", md: "none" },
          gap: 1,
          overflowX: "auto",
          py: 1,
          px: 1,
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
                ? alpha("#0066ff", 0.2)
                : "transparent",
              border: isActiveTab(tab.key)
                ? `1px solid ${alpha("#0066ff", 0.4)}`
                : "1px solid transparent",
              borderRadius: "3px",
              px: 1.5,
              fontSize: "0.7rem",
              fontWeight: 600,
              letterSpacing: "0.3px",
              minHeight: "32px",
              "&:hover": {
                background: alpha("#0066ff", 0.15),
              },
            }}
          >
            {tab.label.split(" ")[0]}
          </Button>
        ))}
      </Toolbar>
    </AppBar>
  );
};

export default AppHeader;
