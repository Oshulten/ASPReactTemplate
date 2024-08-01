import "./App.css";
import DataTable from "./components/DataTable";
import DefaultDataType from "./models/DefaultDataType";

function App() {
    // const data = useFetch<DefaultDataType>(url);

    return <DataTable<DefaultDataType> url="http://localhost:5055/api/Template" />;
    // if (data && data.length > 0) {
    //     const keys = Object.keys(data[0]);
    //     const headerRow = (
    //         <tr>
    //             {keys.map((key) => (
    //                 <th>{key}</th>
    //             ))}
    //         </tr>
    //     );
    //     const rows = data.map((datum) => (
    //         <tr>
    //             {Object.values(datum).map((value) => (
    //                 <td>{value}</td>
    //             ))}
    //         </tr>
    //     ));

    //     return (
    //         <div className="overflow-x-auto">
    //             <h2>List</h2>
    //             <table className="table table-xs">
    //                 <thead>{headerRow}</thead>
    //                 <tbody>{rows}</tbody>
    //             </table>
    //         </div>
    //     );
    // }

    // return (
    //     <>
    //         <p>Loading...</p>
    //     </>
    // );
}

export default App;
