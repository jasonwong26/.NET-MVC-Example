$(document).ready(function () {
    $(document).on('change', 'label.btn input[checkedicon]', function (e) {
        dataEntry.toggleIcon($(this));
    });

    $("#keys").on('touch click', 'thead button', function () {
        dataEntry.appendChildTable();
    });
    $("#keys").on('touch click', 'tbody button', function () {
        rowIndex = $(this).parents('tr').index();
        dataEntry.trimChildTable(rowIndex);
    });

    dataEntry.refreshChildTable();
});

var dataEntry = (function ($) {
    var me = {};

    me.toggleIcon = function ($checkbox) {
        isChecked = $checkbox.is(':checked');
        checkedIcon = $checkbox.attr('checkedicon');
        uncheckedIcon = $checkbox.attr('uncheckedicon');

        $icon = $checkbox.siblings('.glyphicon');
        $icon.toggleClass(checkedIcon, isChecked).toggleClass(uncheckedIcon, !isChecked);
    }

    me.refreshChildTable = function () {
        $("#keys tbody tr:gt(0) button").toggleClass('disabled', false);
    }

    me.appendChildTable = function () {
        $parent = $("#keys tbody");
        $newRow = $parent.find("tr:last").clone();

        $newRow.find('select,input').not('[type="hidden"]').val([]);
        $newRow.find("button").toggleClass('disabled', false);

        newRowIdx = $parent.find("tr").length;
        me.setInputIDs($newRow, newRowIdx);

        $parent.append($newRow);
    }

    me.trimChildTable = function (rowIdx) {
        $parent = $("#keys tbody");
        $deleteRow = $parent.find("tr:eq(" + rowIdx + ")");
        $updateRows = $parent.find("tr:gt(" + rowIdx + ")");

        $deleteRow.remove();

        newRowIdx = rowIdx;
        $updateRows.each(function () {
            me.setInputIDs($(this), newRowIdx);
            newRowIdx++;
        });
    }

    me.setInputIDs = function ($parent, newRowIdx) {
        idRegex = /(Keys_)(\d+)(__.*)/;
        nameRegex = /(Keys\[)(\d+)(\]\..*)/;

        if ($parent) {
            $parent.find("select,input").each(function () {
                newId = $(this).attr("id").replace(idRegex, "$1" + newRowIdx + "$3");
                newName = $(this).attr("name").replace(nameRegex, "$1" + newRowIdx + "$3");

                $(this).attr("id", newId).attr("name", newName);
            });
        }
    }

    return me;
}(jQuery));