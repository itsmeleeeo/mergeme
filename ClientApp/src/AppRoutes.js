import RegisterUser from "./components/RegisterUser";
import Login from "./components/Login";
import { Home } from "./components/Home";
import DashboardDeveloper from './components/DashboardDeveloper'
import DashboardRecruiter from './components/DashboardRecruiter'
import EditProfile from "./components/editDeveloperForm";

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
    element: <EditProfile />
  }
];

export default AppRoutes;
