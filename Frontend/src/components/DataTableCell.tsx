type DataTableCellProps = {
    id: string;
    onChange: () => void;
    value: string;
};

export default function DataTableCell({ onChange, value }: DataTableCellProps) {
    // useEffect(() => {
    //     async function patchValue<T>(setter: React.Dispatch<React.SetStateAction<T[] | undefined>>, url: string) {
    //         const response = await fetch(url);

    //         if (!response.ok) {
    //             throw new Error(
    //                 `Unable to Fetch Data, Please check URL
    //                 or Network connectivity!!`
    //             );
    //         }

    //         const data = (await response.json()) as T[];
    //         setter(data);
    //     }

    //     fetchAll<DataType>(setData, url);
    // }, []);

    return <input type="text" value={value} onChange={() => onChange()} className="input input-bordered w-full max-w-xs" />;
}
