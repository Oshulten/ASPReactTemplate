import { useState } from "react";

type DataTableCellProps = {
    id: string;
    onChange: (value: string) => void;
    value: string;
};

export default function DataTableCell({ id, onChange, value }: DataTableCellProps) {
    const [ownValue, setOwnValue] = useState(value);

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

    return <input type="text" defaultValue={value} onChange={onChange(ownValue)} className="input input-bordered w-full max-w-xs" />;
}
