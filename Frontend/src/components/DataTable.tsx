import Identifiable from "../models/Identifiable";
import useFetchCollection from "./../hooks/useFetch";
import DataTableCell from "./DataTableCell";

type DataTableProps = {
    url: string;
};

export default function DataTable<DataType extends Identifiable>({ url }: DataTableProps) {
    const data = useFetchCollection<DataType>(url) as DataType[];

    if (data && data.length > 0) {
        const firstElement = data[0] as object;
        const keys = Object.keys(firstElement);
        const headerRow = (
            <tr key={0}>
                {keys.map((key) => (
                    <th>{key}</th>
                ))}
            </tr>
        );

        const rows = data.map((datum) => (
            <tr key={datum.id}>
                {Object.entries(datum).map(([key, value]) => (
                    <td>
                        <DataTableCell key={key} id={datum.id} value={value} onChange={() => console.log(`value: ${value}`)} />
                    </td>
                ))}
            </tr>
        ));

        return (
            <div className="overflow-x-auto">
                <h2>List</h2>
                <table className="table table-xs">
                    <thead>{headerRow}</thead>
                    <tbody>{rows}</tbody>
                </table>
            </div>
        );
    }

    return <div className="skeleton h-32 w-32"></div>;
}
