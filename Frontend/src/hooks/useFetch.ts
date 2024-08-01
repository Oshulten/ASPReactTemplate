import { useEffect, useState } from "react";

export default function useFetchCollection<DataType>(url: string) {
    const [data, setData] = useState<DataType[]>();

    useEffect(() => {
        async function fetchAll<T>(setter: React.Dispatch<React.SetStateAction<T[] | undefined>>, url: string) {
            const response = await fetch(url);

            if (!response.ok) {
                throw new Error(
                    `Unable to Fetch Data, Please check URL
                    or Network connectivity!!`
                );
            }

            const data = (await response.json()) as T[];
            setter(data);
        }

        fetchAll<DataType>(setData, url);
    }, []);

    return data;
}
