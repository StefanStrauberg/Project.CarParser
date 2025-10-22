import { createBrowserRouter } from "react-router-dom";
import MainPage from "../../pages/MainPage";
import App from "../layouts/App";
import EngineTypes from "../../pages/EngineTypes";
import PlaceCities from "../../pages/PlaceCities";
import PlaceRegions from "../../pages/PlaceRegions";
import TransmissionTypes from "../../pages/TransmissionTypes";
import LoginPage from "../../pages/LoginPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <MainPage /> },
      { path: "engine-types", element: <EngineTypes /> },
      { path: "place-cities", element: <PlaceCities /> },
      { path: "place-regions", element: <PlaceRegions /> },
      { path: "transmission-types", element: <TransmissionTypes /> },
      { path: "login", element: <LoginPage /> },
    ],
  },
]);
