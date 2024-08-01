import useFetch from "./../hooks/useFetch";

type DataTableProps = {
    url: string;
};

export default function DataTable<DataType>({ url }: DataTableProps) {
    const data = useFetch<DataType>(url) as DataType[];

    if (data && data.length > 0) {
        const firstElement = data[0] as object;
        const keys = Object.keys(firstElement);
        const headerRow = (
            <tr>
                {keys.map((key) => (
                    <th>{key}</th>
                ))}
            </tr>
        );
        const rows = data.map((datum) => (
            <tr>
                {Object.values(datum as DataType[]).map((value) => (
                    <td>{(value as object).toString()}</td>
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

    return (
        <>
            <p>Loading...</p>
        </>
    );
}
