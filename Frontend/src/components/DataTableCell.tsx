type DataTableCellProps = {
    id: string;
    onChange: () => void;
    value: string;
};

export default function DataTableCell({ id, onChange, value }: DataTableCellProps) {
    return <input type="text" placeholder={value} className="input input-bordered w-full max-w-xs" />;
}
