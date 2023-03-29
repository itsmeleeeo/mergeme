import RegisterUser from "./components/RegisterUser";
import Login from "./components/Login";
import { Home } from "./components/Home";
import DashboardDeveloper from './components/DashboardDeveloper'
import DashboardRecruiter from './components/DashboardRecruiter'
import EditDeveloperProfile from "./components/editDeveloperForm";
import EditRecruiterProfile from "./components/editRecruiterForm";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/signup',
    element: <RegisterUser />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/dashboard/developer',
    element: <DashboardDeveloper />
  },
  {
      path: '/dashboard/recruiter',
      element: <DashboardRecruiter />
  },
  {
    path: '/edit',
    element: <EditDeveloperProfile />
  },
  {
    path: '/edit',
    element: <EditRecruiterProfile />
  }
];

export default AppRoutes;
